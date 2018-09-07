select * from [lookuptype]

USE CISOregon_Test
--insert into LookupType (name) values ('CMSSiteURL')
--insert into [Lookup] (LookupTypeID, LookupName, LookupDescription) values (11, 'BenefitsTest', 'test.cisbenefits.org')

--update [Lookup] set LookupDescription = 'test_cisbenefits_org' where lookupid = 123
--update [Lookup] set LookupDescription = 'cisbenefits_org' where lookupid = 123

select * from LookupType where name = 'CMSSiteUrl'
select * from [Lookup] where LookupTypeid = 11


--USE CISOregon
--insert into LookupType (name) values ('CMSSiteURL')