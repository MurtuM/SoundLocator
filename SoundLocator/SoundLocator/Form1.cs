using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Runtime.InteropServices;

namespace SoundLocator
{
    public partial class Form1 : Form
    {
        MMDevice m_device;
        Timer m_timer = new Timer();
        int m_session = 0;
        float[] m_cells;
        int m_fancy_effect = -1;
        public bool m_pure_overlay = false;

        public class Settings
        {
            public int m_num_cells = 40;
            public float m_decay = 0.4f;
            public float m_interval_min = 0.0f;
            public float m_interval_max = 1.0f;
            public Point m_cell_size = new Point(20, 20);
            public Point m_location = new Point(50, 50);
            public string m_last_session = "";
            public float m_curvature = 0.0f;
            public int m_cell_align = 1;
            public int m_cell_spacing = 2;
            public float m_opacity = 1.0f;
        }

        Settings m_settings = new Settings();

        private string SettingsPath {
            get {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SoundLocatorSettings.xml");
            }
        }

        private void SaveSettings()
        {
            var serializer = new XmlSerializer(m_settings.GetType());
            using (var writer = XmlWriter.Create(SettingsPath))
                serializer.Serialize(writer, m_settings);
        }

        private void LoadSettings()
        {
            if (!System.IO.File.Exists(SettingsPath))
                return;

            var serializer = new XmlSerializer(m_settings.GetType());
            using (var reader = XmlReader.Create(SettingsPath))
                m_settings = (Settings)serializer.Deserialize(reader);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var enumerator = new MMDeviceEnumerator();
            m_device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            UpdateSessionList();

            m_timer.Tick += new EventHandler(Update);
            m_timer.Interval = 8;
            m_timer.Start();

            settings_box.MouseDown += (a, b) => { MouseDownMove(a, b); };

            LoadSettings();

            scroll_decay.Value = (int)((m_settings.m_decay / 2.0f) * 109);
            scroll_min.Value = (int)(m_settings.m_interval_min * 109);
            scroll_max.Value = (int)(m_settings.m_interval_max * 109);
            num_cell_count.Value = m_settings.m_num_cells;
            num_cell_x.Value = m_settings.m_cell_size.X;
            num_cell_y.Value = m_settings.m_cell_size.Y;
            scroll_curvature.Value = (int)(m_settings.m_curvature * 9.0f);
            num_cell_spacing.Value = m_settings.m_cell_spacing;
            scroll_opacity.Value = (int)(m_settings.m_opacity * 109);

            Opacity = m_settings.m_opacity;
            Location = m_settings.m_location;

            InitCells();
            ToggleOverlay(false);

            float loudest_session = 0;
            for (int i = 0; i < m_device.AudioSessionManager.Sessions.Count; i++)
            {
                if (GetSessionName(i) == m_settings.m_last_session)
                {
                    m_session = i;
                    break;
                }

                var peak = m_device.AudioSessionManager.Sessions[i].AudioMeterInformation.MasterPeakValue;
                if (peak > loudest_session)
                {
                    m_session = i;
                    loudest_session = peak;
                }
            }

            combo_sessions.SelectedIndex = m_session;

            combo_cell_align.Items.Add("Top");
            combo_cell_align.Items.Add("Center");
            combo_cell_align.Items.Add("Bottom");
            combo_cell_align.SelectedIndex = m_settings.m_cell_align;

            InitUICallbacks();
        }

        private void InitUICallbacks()
        {
            scroll_min.Scroll += (s, e) => {
                scroll_max.Value = Math.Max(scroll_max.Value, scroll_min.Value);
                m_settings.m_interval_min = scroll_min.Value / 100.0f;
                m_settings.m_interval_max = scroll_max.Value / 100.0f;
            };

            scroll_max.Scroll += (s, e) => {
                scroll_min.Value = Math.Min(scroll_max.Value, scroll_min.Value);
                m_settings.m_interval_min = scroll_min.Value / 100.0f;
                m_settings.m_interval_max = scroll_max.Value / 100.0f;
                SaveSettings();
            };

            scroll_decay.Scroll += (s, e) => { m_settings.m_decay = (scroll_decay.Value / 100.0f) * 2.0f; };

            num_cell_x.ValueChanged += (s, e) => { m_settings.m_cell_size.X = (int)num_cell_x.Value; InitCells(); };
            num_cell_y.ValueChanged += (s, e) => { m_settings.m_cell_size.Y = (int)num_cell_y.Value; InitCells(); };
            num_cell_count.ValueChanged += (s, e) => { m_settings.m_num_cells = (int)num_cell_count.Value; InitCells(); };

            button_center.Click += (s, e) => { Center(); };
            button_lock.Click += (s, e) => { m_pure_overlay = true; Close(); };
            button_kill.Click += (ab, cd) => {
                SaveSettings();
                m_timer.Stop();
                Application.Exit();
            };

            scroll_curvature.Scroll += (s, e) => {
                m_settings.m_curvature = scroll_curvature.Value / 10.0f;
                InitCells();
            };

            combo_cell_align.SelectedIndexChanged += (s, e) => {
                m_settings.m_cell_align = combo_cell_align.SelectedIndex;
                InitCells();
            };

            num_cell_spacing.ValueChanged += (s, e) => {
                m_settings.m_cell_spacing = (int) num_cell_spacing.Value;
                InitCells();
            };

            scroll_opacity.Scroll += (s, e) => {
                m_settings.m_opacity = scroll_opacity.Value / 100.0f;
                Opacity = m_settings.m_opacity;
            };

            combo_sessions.DropDown += (s, e) => { UpdateSessionList(); };
            combo_sessions.SelectedIndexChanged += (s, e) => {
                m_session = combo_sessions.SelectedIndex;
                m_settings.m_last_session = GetSessionName(m_session);
            };

            Activated += (s, e) => { ToggleOverlay(false); };
            Deactivate += (s, e) => { ToggleOverlay(true); };
            FormClosing += (s, e) => {
                m_settings.m_location = Location;
                m_timer.Stop();
                SaveSettings();
            };
        }

        private void InitCells()
        {
            m_cells = new float[m_settings.m_num_cells];
            panel_cells.Controls.Clear();
            for (int i = 0; i < m_settings.m_num_cells; i++)
            {
                var h_f = (1.0f - m_settings.m_curvature) + m_settings.m_curvature * 
                    (1 - Math.Sin((m_settings.m_num_cells - i) * Math.PI / m_settings.m_num_cells));
                var height = (int) (h_f * m_settings.m_cell_size.Y);
                var btn = new Button();
                btn.Size = new Size(m_settings.m_cell_size.X, height);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.White;
                int pad_top = 0;
                if (m_settings.m_cell_align == 1)
                    pad_top = (m_settings.m_cell_size.Y - btn.Height) / 2;
                else if (m_settings.m_cell_align == 2)
                    pad_top = m_settings.m_cell_size.Y - btn.Height;
                btn.Margin = new Padding(m_settings.m_cell_spacing, pad_top, 1, 0);
                btn.Enabled = false;
                btn.FlatAppearance.BorderSize = 0;
                panel_cells.Controls.Add(btn);
            }
            settings_box.Location = new Point((panel_cells.Width - settings_box.Width) / 2, settings_box.Location.Y);
            Center();
            UpdateCellBorders();
        }

        public void Update(Object myObject, EventArgs myEventArgs)
        {
            var dt = 0.008f;

            if (m_session >= 0)
            {
                var peaks = m_device.AudioSessionManager.Sessions[m_session].AudioMeterInformation.PeakValues;
                if (peaks.Count >= 2)
                {
                    pbar_peak_l.Value = (int)(peaks[0] * 100.0f);
                    pbar_peak_r.Value = (int)(peaks[1] * 100.0f);
                    
                    var l = Math.Min(1.0f, Math.Max(0.0f, (peaks[0] - m_settings.m_interval_min) / (m_settings.m_interval_max - m_settings.m_interval_min)));
                    var r = Math.Min(1.0f, Math.Max(0.0f, (peaks[1] - m_settings.m_interval_min) / (m_settings.m_interval_max - m_settings.m_interval_min)));

                    //pbar_peak_l.Value = (int)(l * 100.0f);
                    //pbar_peak_r.Value = (int)(r * 100.0f);

                    var volume = Math.Max(l, r);

                    if (volume > 0.0f)
                    {
                        l += 0.001f;
                        r += 0.001f;

                        var balance = 0.0f;
                        if (l > r)
                            balance = (r / l) * 0.5f;
                        else
                            balance = (l / r) * -0.5f + 1.0f;

                        var cell = Math.Min((int)(balance * (m_settings.m_num_cells)), m_settings.m_num_cells - 1);

                        m_cells[cell] = Math.Max(m_cells[cell], volume);
                    }
                }
            }

            for (int i = 0; i < m_settings.m_num_cells; i++)
            {
                m_cells[i] = Math.Max(0.0f, m_cells[i] - dt / m_settings.m_decay);
                (panel_cells.Controls[i] as Button).BackColor = Color.FromArgb((int)(m_cells[i] * 255), 255, 255, 255);
            }

            if (m_fancy_effect > -1)
            {
                if (++m_fancy_effect < m_cells.Length)
                    m_cells[m_fancy_effect] = m_cells[m_cells.Length - 1 - m_fancy_effect] = 1.0f;
                else
                    m_fancy_effect = -1;
            }
        }

        void UpdateSessionList()
        {
            m_device.AudioSessionManager.RefreshSessions();

            combo_sessions.Items.Clear();
            var sessions = m_device.AudioSessionManager.Sessions;
            for (int i = 0; i < sessions.Count; i++)
                combo_sessions.Items.Add(GetSessionName(i));

            combo_sessions.SelectedIndex = m_session;
        }

        string GetSessionName(int session)
        {
            string session_name = "System sounds";
            if (!m_device.AudioSessionManager.Sessions[session].IsSystemSoundsSession)
            {
                session_name = m_device.AudioSessionManager.Sessions[session].GetSessionIdentifier;
                if (session_name.Contains(".exe"))
                {
                    var ex_i = session_name.LastIndexOf(".exe");
                    var filename_i = session_name.LastIndexOf("\\", ex_i, ex_i) + 1;
                    session_name = session_name.Substring(filename_i, ex_i - filename_i);
                }
                //else
                //    session_name = session_name.Substring(0, 4) + "...";
            }
            return session_name;
        }

        private void UpdateCellBorders()
        {
            foreach (Button c in panel_cells.Controls)
                c.FlatAppearance.BorderSize = !settings_box.Visible ? 0 : 1;
        }

        private void ToggleOverlay(bool overlay)
        {
            if (overlay != m_pure_overlay)
                m_fancy_effect = 0;
            if (m_pure_overlay)
                overlay = true;
            settings_box.Visible = button_kill.Visible = button_center.Visible = !overlay;
            UpdateCellBorders();
        }

        private void Center()
        {
            Location = new Point((Screen.FromHandle(Handle).Bounds.Width - panel_cells.Width) / 2, Location.Y);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void MouseDownMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
