namespace JMMinistry.Domain;

public partial class ClassStudent
{
    public int Id { get; set; }
    public int? ClassId { get; set; }
    public Class Class { get; set; } = null!;

    public string StudentId { get; set; } = null!;
    public PersonalInfo Student { get; set; } = null!;

    public bool Paid { get; set; }

    public decimal Debt { get; set; }

}
