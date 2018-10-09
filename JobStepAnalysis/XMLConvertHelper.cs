namespace JobStepAnalysis
{
    public class XMLConvertHelper : IXMLConvertHelper
    {
        public T Deserialize<T>(string xml)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IXMLConvertHelper
    {
        T Deserialize<T>(string xml);
    }

}