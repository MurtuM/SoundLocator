using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLocator
{
    class CLInumerator : System.Collections.IEnumerator
    {
        int m_index = -1;
        CircularList m_list;
        public CLInumerator(CircularList list)
        {
            m_list = list;
        }

        public bool MoveNext()
        {
            m_index++;
            return (m_index < m_list.Count);
        }

        public void Reset()
        { m_index = -1; }

        public object Current
        {
            get { return m_list[m_index]; }
        }
    };

    class CircularList : System.Collections.IEnumerable
    {
        float[] m_list = null;
        int m_next = 0;
        int m_count = 0;
        int m_size = 0;

        public CircularList(int size)
        {
            m_list = new float[size];
            m_size = size;
        }
        public int Count
        {
            get { return m_count; }
        }
        public float this[int i]
        {
            get
            {
                if (i > m_count || i < 0)
                    throw new IndexOutOfRangeException();
                if (m_count == m_size)
                    return m_list[(m_next + i) % m_size];
                else
                    return m_list[i];
            }
            set
            {
                if (i > m_count || i < 0)
                    throw new IndexOutOfRangeException();
                if (m_count == m_size)
                    m_list[(m_next + i) % m_size] = value;
                else
                    m_list[i] = value;
            }
        }
        public void Add(float value)
        {
            m_count = Math.Min(m_count + 1, m_size);
            m_list[m_next] = value;
            m_next = (m_next + 1) % m_size;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new CLInumerator(this);
        }
    }
}
