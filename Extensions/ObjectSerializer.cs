using System.Xml.Serialization;

namespace Appointment.Extensions
{
    public static class ObjectSerializer
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
