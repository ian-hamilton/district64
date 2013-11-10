
begin transaction

delete from archive_repos_type

insert into archive_repos_type values(1, 'Schedule', 1)
insert into archive_repos_type values(2, 'Letter', 1)
insert into archive_repos_type values(3, 'Minutes', 1)
insert into archive_repos_type values(4, 'Flyers', 1)
insert into archive_repos_type values(5, 'Pass It On', 1)
insert into archive_repos_type values(6, 'Conference', 1)
insert into archive_repos_type values(7, 'Assembly', 1)
insert into archive_repos_type values(8, 'Article', 1)
insert into archive_repos_type values(9, 'Concepts', 1)
insert into archive_repos_type values(10, 'Misc', 1)
commit transaction
