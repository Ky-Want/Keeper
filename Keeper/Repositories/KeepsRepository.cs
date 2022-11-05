namespace Keeper.Repositories;


public class KeepsRepository : BaseRepository
{
  internal List<Keep> GetKeeps()
  {
    // FIXME: cannot have creator populated

    var sql = @"
      SELECT * FROM keepDTO
    ;";
    return _db.Query<Keep>(sql).ToList();
  }







  internal Keep CreateKeep(Keep newKeep)
  {
    var sql = @"
      INSERT INTO keeps(
    img, 
    name, 
    description, 
    creatorId, 
    views, 
    kept
    )
      VALUES(
    @Img, 
    @Name, 
    @Description, 
    @CreatorId, 
    @Views, 
    @Kept
    );
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, newKeep);
    newKeep.Id = id;
    return newKeep;
  }







  public KeepsRepository(IDbConnection db) : base(db) { }
}