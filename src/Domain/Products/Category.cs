using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreateBy = createBy;
        CreateOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();

    }

    private void Validate()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name")
                    .IsGreaterOrEqualsThan(Name, 3, "Name")
                    .IsNotNullOrEmpty(CreateBy, "CreateBy")
                    .IsNotNullOrEmpty(EditedBy, "EditedOn");
        AddNotifications(contract);
    }
    public void EditInfo(string name, bool active)
    {
        Name = name;
        Active = active;

        Validate();
    }
}
