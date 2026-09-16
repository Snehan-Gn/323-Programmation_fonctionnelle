using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeries
{
    public class DataSeries<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _data;

        private DataSeries(IEnumerable<T> data) => _data = data;

        public static DataSeries<T> From(IEnumerable<T> source)
            => new DataSeries<T>(source);

        public int Count => _data.Count();
        public IEnumerable<T> Values => _data;

        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static DataSeries<T> FromCsv(string path, Func<string[], T> parser)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("CSV file not found.", path);

            var parsedData = File.ReadLines(path)
                                 .Skip(1)
                                 .Where(line => !string.IsNullOrWhiteSpace(line))
                                 .Select(line => parser(line.Split(',')));

            return new DataSeries<T>(parsedData);
        }

        public DataSeries<T> Filter(Func<T, bool> predicate)
            => new DataSeries<T>(_data.Where(predicate));
        public DataSeries<T> RemoveOutliers(Func<T, bool> isValid)
            => Filter(isValid);
        public bool HasAny(Func<T, bool> predicate)
            => _data.Any(predicate);
        public bool AllMatch(Func<T, bool> predicate)
            => _data.All(predicate);
    }

}
