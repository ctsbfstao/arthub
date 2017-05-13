using ArtHub.Models;

namespace ArtHub.Application
{
    public interface IExhibitCommand
    {
        void Create(Exhibit exhibit);

    }
}