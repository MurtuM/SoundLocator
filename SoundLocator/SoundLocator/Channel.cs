using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLocator
{
    class Channel
    {
        private CircularList m_short = new CircularList(60); // 60 frames = 1 sec
        private CircularList m_medium = new CircularList(10); // 60 * 10 = 10 sec
        private CircularList m_long = new CircularList(10);  // 60 * 10 * 10 = 100 sec

        int m_medium_counter = 0;
        int m_long_counter = 0;

        float m_short_avg = -1;
        float m_medium_avg = -1;
        float m_long_avg = -1;

        private float CalcAvg(CircularList list)
        {
            float avg = 0;
            foreach (float v in list)
                avg += v;
            avg /= list.Count;
            return avg;
        }

        public void AddVolume(float value)
        {
            m_short.Add(value);
            m_short_avg = -1;
            if ((m_medium_counter % 10) == 0 || m_medium_counter < 10)
            {
                m_short_avg = CalcAvg(m_short);
                m_medium.Add(m_short_avg);

                if ((m_long_counter % 10) == 0 || m_long_counter < 10)
                {
                    m_medium_avg = CalcAvg(m_medium);                    
                    m_long.Add(m_medium_avg);

                    m_long_avg = CalcAvg(m_long);
                }
                m_long_counter++;
            }
            m_medium_counter++;
        }

        public float ShortAverage
        {
            get
            {
                if (m_short_avg < 0)
                    m_short_avg = CalcAvg(m_short);
                return m_short_avg;
            }
        }

        public float MediumAverage
        {
            get
            {
                if (m_medium_avg < 0)
                    m_medium_avg = CalcAvg(m_medium);
                return m_medium_avg;
            }
        }

        public float LongAverage
        {
            get
            {
                if (m_long_avg < 0)
                    m_long_avg = CalcAvg(m_long);
                return m_long_avg;
            }
        }
    }
}
