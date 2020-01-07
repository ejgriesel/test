

create proc [dbo].[spGetInstructionsWithUnknownStatus]
  @ChannelId int,
  @After datetime
as
select
  *
from instruction
where
  channelid = @ChannelId and
  datetime >= @After and
  instancestatus is NULL


