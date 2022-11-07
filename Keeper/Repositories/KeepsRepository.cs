namespace Keeper.Repositories;


public class KeepsRepository : BaseRepository
{
  internal List<Keep> GetKeeps()
  {
    // NOTE: left join adds everything in, 
    // NOTE: inner join gets rid of duplicate data
    var sql = @"
      SELECT 
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
        GROUP BY (k.id)
    ;";
    return _db.Query<Keep, Profile, Keep>(sql, (ke, p) =>
    {
      ke.Creator = p;
      return ke;
    }).ToList();
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