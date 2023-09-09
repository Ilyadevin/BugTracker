internal class Person
{
    private Guid guid;
    private string Login;
    private string Password;

    public Person(Guid guid, string v1, string v2)
    {
        this.guid = guid;
        this.Login = v1;
        this.Password = v2;
    }
}