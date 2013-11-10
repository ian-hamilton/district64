create table archive_repos_type
(archive_repos_type_id bigint not null,
archive_repos_type_desc varchar(25) not null,
status_flag int not null)

alter table archive_repos_type
add constraint pk_archive_repos_type
primary key (archive_repos_type_id)

go
