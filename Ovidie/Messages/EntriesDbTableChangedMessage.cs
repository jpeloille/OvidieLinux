using CommunityToolkit.Mvvm.Messaging.Messages;
using Ovidie.EntityModel.SqlServer.Entities;

namespace Ovidie.Messages;

public class EntriesDbTableChangedMessage(TEcriture entry) : ValueChangedMessage<TEcriture>(entry);