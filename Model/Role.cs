namespace DevNot21.Model;
public record Role(int RoleID, string RoleName, int GroupID)
{
    public bool HasRole(int access, int roleID)
    {
        return roleID == (access & roleID);
    }
}

