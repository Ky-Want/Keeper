namespace Keeper.Repositories;


public class VaultKeepsRepository : BaseRepository
{
  public List<VaultKeep> GetKeepByVaultId(int id)
  {
    var sql = @"
    SELECT
    vk.*,
    a.*
    FROM vaultKeeps vk
    JOIN accounts a ON a.id = vk.creatorId
    WHERE vk.vaultId = @vaultId
    ;";

    return _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vk, p) =>
    {
      vk.Creator = p;
      return vk;
    }, new { id }).ToList();
  }






  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
  {
    var sql = @"
  INSERT INTO vaultKeeps(
    vaultId, 
    keepId
  )VALUES(
    @VaultId,
    @KeepId
  );
  SELECT LAST_INSERT_ID()
  ;";

    int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
    newVaultKeep.Id = id;
    return newVaultKeep;
  }



  internal void DeleteVaultKeep(VaultKeep foundKeep)
  {
    var sql = @"
    DELETE FROM vaultKeeps
    WHERE id = @Id
    LIMIT 1
    ;";

    _db.Execute(sql, foundKeep);
  }





  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }
}