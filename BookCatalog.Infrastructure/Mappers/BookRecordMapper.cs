using CsvHelper.Configuration;

public class BookRecordMapper : ClassMap<BookRecord>
{
    public BookRecordMapper()
    {
        Map(m => m.Creator).Name("creator");
        Map(m => m.Format).Name("format");
        Map(m => m.Identifier).Name("identifier");
        Map(m => m.PublicDate).Name("publicdate");
        Map(m => m.Publisher).Name("publisher");
        Map(m => m.RelatedExternalId).Name("related-external-id");
        Map(m => m.Title).Name("title");
    }
}
