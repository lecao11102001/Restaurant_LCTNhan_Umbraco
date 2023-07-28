var img_view = document.getElementById('img_view');
// Gọi API khi click vào nút
ing_view.addEventListener('click', function () {
    //var nodeId = this.getAttribute('data');
    //console.log(nodeId);
    //incrementViewCount(nodeId);
});

// Hàm gọi API đếm view
function incrementViewCount(nodeId) {
    $.ajax({
        url: '/api/Stories',
        method: 'POST',
        data: { nodeId: nodeId },
        success: function () {
            console.log('Thành Công !!!');
        },
        error: function () {
            console.log('Thất Bại !!!');
        }
    });
}

// Search
//function search() {
//    var key = document.getElementById('keyword').value;
    
//}