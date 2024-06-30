using Dalamud.Interface.Internal;
using Dalamud.Interface.Textures.TextureWraps;
using ImGuiScene;

namespace PunishLib.ImGuiMethods;

internal class ImageLoadingResult
{
    internal IDalamudTextureWrap texture = null;
    internal bool isCompleted = false;
}
