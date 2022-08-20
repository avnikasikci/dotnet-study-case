using Infrastructure.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OcrConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            string JsonText = System.IO.File.ReadAllText(@"D:\Avni\Projects\ProjectCaseStudy\Kaizen\StudyCase\dotnet-study-case\WebApi\response.json");
            //var JsonObj = UtilityJson.JsonDeserialize<List<dynamic>>(JsonText).ToList();
            var OcrModelList = UtilityJson.JsonDeserialize<List<OcrModel>>(JsonText).ToList();
            OcrModelList.RemoveAt(0);
            //public virtual IList<NewsAgencyTranslate> translateList { get => (UtilityJson.JsonDeserialize<IList<NewsAgencyTranslate>>(JsonTranslate)); set { JsonTranslate = UtilityJson.JsonSerialize(value); } }

            var result = new List<OcrResult>();

            for (int i = 0; i < OcrModelList.ToList().Count; i++)
            {
                try
                {
                    var Entity = OcrModelList[i];
                    var EntityNext = (i>=OcrModelList.Count-1)? new OcrModel():OcrModelList[i + 1];
                    var EntityBefore = (i > 0) ? OcrModelList[i - 1] : new OcrModel();

                    var vertice = Entity.boundingPoly.vertices[0].y;
                    var verticeNext = EntityNext?.boundingPoly?.vertices[0].y ?? 0;
                    var verticeBefore = EntityBefore.boundingPoly?.vertices[0].y ?? 0;
                    //var verticeDiffNext = (verticeNext - vertice);

                    //var verticeDiffNext = (verticeNext - vertice) <0 ? (verticeNext - vertice) * -1 : (verticeNext - vertice);
                    var verticeDiffBefore = (verticeBefore - vertice) < 0 ? (verticeBefore - vertice) * -1 : (verticeBefore - vertice);
                    if (verticeDiffBefore > 15)
                    {
                        var resultEntity1 = new OcrResult();
                        resultEntity1.Line = result.ToList().Count() + 1;
                        resultEntity1.Text = Entity.description;
                        result.Add(resultEntity1);

                    }
                    else
                    {
                        var resultEntityBefore = new OcrResult();
                        resultEntityBefore = result[result.ToList().Count - 1];
                        resultEntityBefore.Text = resultEntityBefore.Text + " " + Entity.description;

                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }

            Console.WriteLine(result);
        }
    }
}
