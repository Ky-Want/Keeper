namespace Keeper.Repositories;


public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }




  // get by id
  // internal List<Keep> GetKeepsByVaultId(int vaultId)
  // {
  //   var sql = @"
  //   SELECT
  //   k.*,
  //   a.*
  //   FROM keeps k
  //   JOIN accounts a ON a.id = k.creatorId
  //   WHERE k.keepId = @keepId
  //   ;";

  //   return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
  //   {
  //     keep.CreatorId = profile;
  //     return keep;
  //   }, new { vaultId }).ToList();
  // }







  internal Vault CreateVault(Vault newVault)
  {
    var sql = @"
    INSERT INTO vaults(
      name,
      creatorId, 
      description, 
      isPrivate, 
      img)
    VALUES(
      @Name, 
      @CreatorId
      @Description, 
      @IsPrivate, 
      @Img);
    SELECT LAST_INSERT_ID()
    ;";

    int newVaultId = _db.ExecuteScalar<int>(sql, newVault);
    newVault.Id = newVaultId;
    return newVault;
  }


  // delete







  // edit
}