namespace UserLogin
{
    enum UserRoles
    {
        ANONYMOUS = 0, 
        ADMIN = 1, 
        INSPECTOR = 2, 
        PROFESSOR = 3, 
        STUDENT = 4
    }


    enum Activities
    {
        UserLogin = 0,
        UserChanged = 1,
        UserActiveToChange = 2
    }
}