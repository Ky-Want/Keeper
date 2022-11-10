namespace Keeper.Repositories;


public class VaultKeepsRepository : BaseRepository
{
  internal List<KeepsInVault> GetVaultKeepsByVaultId(int id)
  {
    var sql = @"
    SELECT
      a.*,
      k.*,
      vk.id AS vaultKeepId
    FROM vaultKeeps vk 
    JOIN accounts a ON vk.creatorId = a.id
    JOIN keeps k ON vk.keepId = k.id
    WHERE vk.vaultId = @id;
    ";

    return _db.Query<Profile, KeepsInVault, KeepsInVault>(sql, (p, kv) =>
    {
      kv.Creator = p;
      return kv;
    }, new { id }).ToList();
  }







  // REVIEW: Parameter '@VaultId' must be defined. To use this as a variable, set 'Allow User Variables=true' in the connection string.
  // ^  = missing inserts (id & creatorId)
  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
  {
    var sql = @"
  INSERT INTO vaultKeeps(
    vaultId, 
    keepId,
    creatorId
  )VALUES(
    @VaultId,
    @KeepId,
    @CreatorId
  );
  SELECT LAST_INSERT_ID()
  ;";

    int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
    newVaultKeep.Id = id;
    return newVaultKeep;
  }








  internal void DeleteVaultKeep(VaultKeep foundVK)
  {
    var sql = @"
    DELETE FROM vaultKeeps WHERE id = @Id LIMIT 1
    ;";

    _db.Execute(sql, foundVK);
  }




  internal VaultKeep GetById(int id)
  {
    var sql = "SELECT * FROM vaultKeeps WHERE id = @id";
    return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
  }

  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }
}