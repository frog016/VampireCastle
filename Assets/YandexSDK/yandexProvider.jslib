mergeInto(LibraryManager.library, {
  InitPurchases: function() {
    initPayments();
  },

  Purchase: function(id) {
    buy(id);
  },

  AuthenticateUser: function() {
    auth();
  },

  GetUserData: function() {
    getUserData();
  },

  SetUserData: function(data) {
    setUserData(data);
  },

  ShowFullscreenAd: function () {
    showFullscrenAd();
  },

  ShowRewardedAd: function(placement) {
    showRewardedAd(placement);
    return placement;
  },

  GetLeaderBoard: function() {
    getLeaderBoard();
  },

  WriteLeaderBoardScore: function(score) {
    writeLeaderBoard(score);
  },

  OpenWindow: function(link){
    var url = Pointer_stringify(link);
      document.onmouseup = function()
      {
        window.open(url);
        document.onmouseup = null;
      }
  },
});