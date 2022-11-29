namespace Models.Entities;

public record Category
{
    private int _id;
    private string _name;
    private int? _parentId;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int? ParentId
    {
        get => _parentId;
        set => _parentId = value;
    }

    public Category(int id, string name, int? parentId)
    {
        _id = id;
        _name = name;
        _parentId = parentId;
    }

    public Category(int id, string name)
    {
        _id = id;
        _name = name;
    }
    
    
}