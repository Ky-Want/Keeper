namespace Keeper.Repositories;


public class VaultKeepsRepository : BaseRepository
{
  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }


  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    var sql = @"
    SELECT
    *
    FROM vaultKeeps
    WHERE id = vaultKeepId
    ;";

    return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultKeepId });
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



  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
  {
    var sql = @"
    INSERT INTO vaultKeeps(vaultId, keepId)
    VALUES(@VaultId, @KeepId);
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
    newVaultKeep.Id = id;
    return newVaultKeep;
  }
}