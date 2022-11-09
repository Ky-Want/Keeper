namespace Keeper.Repositories;


public class VaultKeepsRepository : BaseRepository
{
  // FIXME: Parameter '@VaultId' must be defined.To use this as a variable, set 'Allow Use
  internal VaultKeep GetVaultKeepById(int id)
  {
    var sql = @"
    SELECT * FROM vaultKeeps WHERE id = @id
    ;";

    return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
  }













  // FIXME: Parameter '@VaultId' must be defined. To use this as a variable, set 'Allow User Variables=true' in the connection string.
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








  // FIXME: Parameter '@VaultId' must be defined. To use this as a variable, set 'Allow Use
  internal void DeleteVaultKeep(VaultKeep foundVK)
  {
    var sql = @"
    DELETE FROM vaultKeeps WHERE id = @Id LIMIT 1
    ;";

    _db.Execute(sql, foundVK);
  }





  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }
}