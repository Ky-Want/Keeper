namespace Keeper.Repositories;


public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }




  internal Profile GetUserById(string id)
  {
    var sql = @"
      SELECT * FROM accounts WHERE id = @id;
    ";
    return _db.Query<Profile>(sql, new { id }).FirstOrDefault();
  }







  public List<MyKeeps> GetUsersKeeps(string id)
  {
    var sql = @"
      SELECT 
        k.*,
        a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE creatorId = @id
    ;";

    return _db.Query<MyKeeps, Profile, MyKeeps>(sql, (mk, profile) =>
    {
      mk.Creator = profile;
      return mk;
    }, new { id }).ToList();
  }



  public List<Vault> GetUsersVaults(string id)
  {
    var sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE creatorId = @id
    ;";

    return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
    {
      v.Creator = p;
      return v;
    }, new { id }).ToList();
  }
}