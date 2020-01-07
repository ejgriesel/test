
create proc spGetSetupFeaturesByChannelId
  @ChannelId int
as
select
  [sf].[created] as Created,
  [sf].[updated] as Updated,
  [sf].[name] as Name,
  [sf].[value] as Value
from setup as s
left join setupfeature as sf
on
  s.id = sf.setupid
where
  s.channelid = @ChannelId

