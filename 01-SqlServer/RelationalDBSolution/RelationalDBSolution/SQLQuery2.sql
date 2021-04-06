
select e. *
from dbo.EmailAddresses E
inner join dbo.ContactEmail ce on ce.EmailAddressId = e.Id
where ce.ContactId = 1