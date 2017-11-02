using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using POP_SF49_16.Model;

namespace POP_SF49_16.Utils
{
    class GemericSerializer
    {
        public static List<T> Deserializer<T>(string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sr = new StreamReader($@"../../Data{ fileName }"))
                {
                    return (List<T>)serializer.Deserialize(sr);
                }
    

            }
            catch (Exception ex)
            {

                throw new Exception($"Greska prilikom ucitavanja datoteke: {fileName}");
            }
        }
        public static void Seserializer<T>(string fileName,List<T> listtoserialize) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sr = new StreamWriter($@"../../Data/{ fileName }"))
                {
                    serializer.Serialize(sr, listtoserialize);
                }


            }
            catch (Exception)
            {

                throw new Exception(message: $"Greska prilikom ucitavanja datoteke: {fileName}");
            }
        }
    }
}
