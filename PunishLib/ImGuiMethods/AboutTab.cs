using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Components;
using Dalamud.Interface.Internal.Notifications;
using Dalamud.Plugin;
using ECommons.Automation;
using ImGuiNET;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PunishLib.ImGuiMethods
{
    public static class AboutTab
    {
        private static string _inputKey = string.Empty;
        private static bool openApiSettings = false;
        private static bool showKeyError = false;
        private static bool showSuccess = false;

        static string GetImageURL()
        {
            return PunishLibMain.PluginManifest.IconUrl ?? "";
        }

        public static void Draw(IDalamudPlugin P)
        {
            ImGuiEx.ImGuiLineCentered("About1", delegate
            {
                ImGuiEx.Text($"{P.Name} - {PunishLibMain.PluginManifest.AssemblyVersion}");
            });

            PunishLibMain.About.WithLoveBy();

            ImGuiHelpers.ScaledDummy(10f);
            ImGuiEx.ImGuiLineCentered("About2", delegate
            {
                if (ThreadLoadImageHandler.TryGetTextureWrap(GetImageURL(), out var texture))
                {
                    ImGui.Image(texture.ImGuiHandle, new(200f, 200f));
                }
            });
            ImGuiHelpers.ScaledDummy(10f);
            ImGuiEx.ImGuiLineCentered("About3", delegate
            {
                /*if (ImGuiEx.IconButton((FontAwesomeIcon)0xf392))
                {
                    GenericHelpers.ShellStart("https://discord.gg/Zzrcc8kmvy");
                }
                ImGui.SameLine();*/
                ImGui.TextWrapped("Join our Discord community for project announcements, updates, and support.");
            });
            ImGuiEx.ImGuiLineCentered("About4", delegate
            {
                if (ImGui.Button("Discord"))
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = "https://discord.gg/Zzrcc8kmvy",
                        UseShellExecute = true
                    });
                }
                ImGui.SameLine();
                if (ImGui.Button("Repository"))
                {
                    ImGui.SetClipboardText("https://love.puni.sh/ment.json");
                    PunishLibMain.PluginInterface.UiBuilder.AddNotification("Link copied to clipboard", PunishLibMain.PluginName, NotificationType.Success);
                }
                if (PunishLibMain.PluginManifest.RepoUrl != null)
                {
                    ImGui.SameLine();
                    if (ImGui.Button("Source Code"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = PunishLibMain.PluginManifest.RepoUrl,
                            UseShellExecute = true
                        });
                    }
                }
                if (PunishLibMain.About.Sponsor != null)
                {
                    ImGui.SameLine();
                    if (ImGui.Button("Sponsor"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = PunishLibMain.About.Sponsor,
                            UseShellExecute = true
                        });
                    }
                }

                ImGui.SameLine();
                if (ImGuiComponents.IconButton(FontAwesomeIcon.Cog))
                {
                    openApiSettings = true;
                }

                if (openApiSettings)
                {
                    ImGuiHelpers.ForceNextWindowMainViewport();
                    ImGui.SetNextWindowSize(new System.Numerics.Vector2(200, 300), ImGuiCond.Once);
                    ImGui.Begin($"Puni.sh API Key Settings", ref openApiSettings, ImGuiWindowFlags.AlwaysAutoResize);
                    ImGui.Text("API Key");
                    if (showKeyError)
                        ImGuiEx.Text(ImGuiColors.DalamudRed, "ERROR - Invalid API Key");

                    if (showSuccess)
                        ImGuiEx.Text(ImGuiColors.HealerGreen, "Success - Your key has been saved.");

                    ImGui.PushItemWidth(300);
                    if (ImGui.InputText("", ref _inputKey, 100))
                    {
                        showKeyError = false;
                        showSuccess = false;
                    }

                    if (ImGui.Button("Diagnostics Export"))
                    {

                    }

                    ImGui.SameLine();
                    if (ImGuiComponents.IconButton(FontAwesomeIcon.Save))
                    {
                        Regex uuidPattern = new Regex("[a-fA-F\\d]{8}(?:\\-[a-fA-F\\d]{4}){3}\\-[a-fA-F\\d]{12}$");
                        if (uuidPattern.IsMatch(_inputKey))
                        {
                            showKeyError = false;
                            showSuccess = true;

                            PunishLibMain.PunishConfig.APIKey = _inputKey;
                            PunishLibMain.PunishConfig.Save();
                        }
                        else
                        {
                            showSuccess = false;
                            showKeyError = true;
                        }

                    }
                    ImGui.End();
                }
            });
        }
    }
}
