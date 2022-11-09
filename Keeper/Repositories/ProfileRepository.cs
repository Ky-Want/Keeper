namespace Keeper.Repositories;


public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }




  // get a users profile
  public Profile GetUserById(int userId)
  {
    var sql = @"
      SELECT * FROM accounts WHERE id = @userId
    ;";
    return _db.Query<Profile>(sql, new { userId }).FirstOrDefault();
  }







  // get a users keeps


  // get a users vaults
}