function shareOnFacebook() {
    // Lấy thông tin từ các thẻ meta đã định nghĩa
    var title = document.querySelector('meta[property="og:title"]').getAttribute('content');
    var url = document.querySelector('meta[property="og:url"]').getAttribute('content');
    var image = document.querySelector('meta[property="og:image"]').getAttribute('content');

    // Tạo URL chia sẻ Facebook
    var shareUrl = 'https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(url);
    // Mở cửa sổ chia sẻ Facebook
    window.open(shareUrl);
}
