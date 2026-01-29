namespace Core_HomeService.Domain.Core.UserAgg.DTOs.WalletDTOs
{
    public class WalletTransferDto
    {
        public int CustomerUserId { get; set; }
        public int ExpertUserId { get; set; }
        public int Amount { get; set; }
    }
}
