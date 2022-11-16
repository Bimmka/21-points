namespace Features.Services.Cleanup
{
  public interface ICleanupService
  {
    void Register(ICleanup cleanup);
    void Unregister(ICleanup cleanup);
    void Cleanup();
    void Clear();
  }
}