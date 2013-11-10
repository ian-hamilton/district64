create table archive_repos
(archive_repos_id bigint identity(1,1) not null,
archive_repos_short_desc varchar(50) not null,
archive_repos_long_desc varchar(1000) null,
archive_year int null,
district_number int null,
archive_repos_type_id bigint not null,
file_repository_id bigint null,
file_path varchar(max) null,
featured_item_flag int not null,
status_flag int not null,
row_created datetime not null,
row_updated datetime not null,
row_created_by_user_id bigint not null,
row_updated_by_user_id bigint not null)

alter table archive_repos
add constraint pk_archive_repos
primary key (archive_repos_id)

alter table archive_repos
add constraint fk_archive_repos_1
foreign key (archive_repos_type_id)
references archive_repos_type(archive_repos_type_id)

create nonclustered index ix_archive_repos_1
on archive_repos(archive_repos_type_id)

alter table archive_repos
add constraint fk_archive_repos_2
foreign key (file_repository_id)
references file_repository(file_repository_id)

create nonclustered index ix_archive_repos_2
on archive_repos(file_repository_id)

go