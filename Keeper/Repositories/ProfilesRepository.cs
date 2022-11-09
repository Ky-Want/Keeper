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







  // get a users keeps
  // public List<MyKeep> GetMyKeeps(string creatorId)
  // {
  //   var sql = @"
  //     SELECT 
  //       keep.*,
  //       a.*,
  //       vault.*
  //     FROM keeps keep
  //     JOIN accounts a ON a.id = keep.creatorId
  //     JOIN vaults vault ON vault.id = keep.vaultId
  //     WHERE keep.creatorId = @creatorId
  //   ;";

  // return _db.Query<MyKeep, Profile, Vault, MyKeep>(sql, (mk, profile, vault) =>
  // {
  //   mk.Vault = vault;
  //   mk.Creator = profile;
  //   return mk;
  // }, new { creatorId }).ToList();
  // }


  // get a users vaults

}