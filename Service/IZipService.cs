
namespace DevNot2021.Services;
public interface IZipService
{
    IEnumerable<string> ZipResult(List<string> list1, List<string> list2, List<long?> list3);
}

public class ZipService : IZipService
{
    public IEnumerable<string> ZipResult(List<string> list1, List<string> list2, List<long?> list3)
    {
        //var resultList = new List<(string, string, long?)>();

        foreach ((string name, string role, long? action) in Enumerable.Zip(list1, list2, list3))
        {
            yield return $"{name} - {role} - {action}";
            //resultList.Add((name, role, action));
        }
        //string result = string.Empty;
        //result = string.Join(",", resultList.Select(t => $"{t.Item1.ToString()} - {t.Item2} - {t.Item3} " + System.Environment.NewLine));
        //return result;
    }
}

