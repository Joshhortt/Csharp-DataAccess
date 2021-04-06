select e. *, ce. *
from dbo.EmailAddresses E
inner join dbo.ContactEmail ce on ce.EmailAddressId = e.Id