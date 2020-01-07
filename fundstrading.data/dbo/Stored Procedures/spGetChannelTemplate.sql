
create proc spGetChannelTemplate
  @ChannelId int,
  @InvestorTypeId int
as
select
  template
from channeltemplate
where
  channelid = @ChannelId and
  investortypeid = @InvestorTypeId

