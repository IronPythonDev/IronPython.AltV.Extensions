using AltV.Net;

namespace IronPython.AltV.Extensions
{
    public static class MValueWriterExtensions
    {
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, string value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, double value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, bool value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, uint value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, int value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }
        public static IMValueWriter WriteProperty(this IMValueWriter writer, string propertyName, float value)
        {
            writer.Name(propertyName);
            writer.Value(value);

            return writer;
        }

        public static IMValueWriter WriteArray(this IMValueWriter writer, string propertyName, IEnumerable<string> values)
        {
            if (!string.IsNullOrEmpty(propertyName)) writer.Name(propertyName);
            writer.BeginArray();

            foreach (var value in values) writer.Value(value);

            writer.EndArray();

            return writer;
        }
        public static IMValueWriter WriteArray<TObject>(this IMValueWriter writer, string propertyName, IEnumerable<TObject> values) where TObject : IWritable
        {
            if (!string.IsNullOrEmpty(propertyName)) writer.Name(propertyName);
            writer.BeginArray();

            foreach (var value in values) value.OnWrite(writer);

            writer.EndArray();

            return writer;
        }

        public static void WriteObject(this IMValueWriter writer, Action<IMValueWriter> inner)
        {
            writer.BeginObject();

            inner.Invoke(writer);

            writer.EndObject();
        }

        public static IMValueWriter BeginObject(this IMValueWriter writer, string name)
        {
            if (!string.IsNullOrEmpty(name)) writer.Name(name);

            writer.BeginObject();

            return writer;
        }

        public static IMValueWriter EndObject(this IMValueWriter writer)
        {
            writer.EndObject();

            return writer;
        }
    }
}