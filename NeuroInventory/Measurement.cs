using System;

namespace NeuroInventory
{
    public abstract class Measurement<T>
    {
        protected T m_Value;

        public T value
        {
            get
            {
                return value;
            }
            set
            {
                m_Value = value;
            }
        }

        public abstract string GetText();
        public abstract int GetDecimalPlaces();
        public abstract int GetID();
        public abstract bool IsNull();
    }

    public class MeasurementNull : Measurement<bool>
    {
        public override int GetDecimalPlaces()
        {
            return 0;
        }

        public override int GetID()
        {
            return 0;
        }

        public override string GetText()
        {
            return String.Empty;
        }

        public override string ToString()
        {
            return String.Empty;
        }

        public override bool IsNull()
        {
            return true;
        }
    }

    public class MeasurementUnit : Measurement<int>
    {
        public override int GetDecimalPlaces()
        {
            return 0;
        }

        public override string GetText()
        {
            return "Единица";
        }

        public override string ToString()
        {
            return "Единица";
        }

        public override int GetID()
        {
            return 1;
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    public class MeasurementWeigh : Measurement<float>
    {
        public override int GetDecimalPlaces()
        {
            return 3;
        }

        public override string GetText()
        {
            return "Килограмм";
        }

        public override string ToString()
        {
            return "Килограмм";
        }

        public override int GetID()
        {
            return 2;
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    public class MeasurementSquare : Measurement<float>
    {
        public override int GetDecimalPlaces()
        {
            return 3;
        }

        public override string GetText()
        {
            return "Кв. метр";
        }

        public override string ToString()
        {
            return "Кв. метр";
        }

        public override int GetID()
        {
            return 3;
        }

        public override bool IsNull()
        {
            return false;
        }
    }
}
