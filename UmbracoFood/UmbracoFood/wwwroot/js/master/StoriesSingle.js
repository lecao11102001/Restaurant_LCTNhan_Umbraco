//Viết ajax ko load lại trang của phần comment
var cmtform = document.getElementById('commentForm');
cmtform.addEventListener('click', function (e) {
    e.preventDefault(); //ngăn chặn load lại trang

    var name = document.getElementById('name').value;
    var email = document.getElementById('email').value;
    var message = document.getElementById('message').value;
    var date = new Date();
    console.log(date.toLocaleDateString()+ ' ' + date.toLocaleTimeString());
    
    var cmtid = document.getElementById('cmtId').value;

    var comment = {
        name: name,
        email: email,
        message: message,
        date: date,
        cmtId: cmtid
    };
    $.ajax({
        url: '/api/CommentStories',
        method: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(comment),
        success: function () {
            updateCommentSection(comment);
        },
        error: function () {
            alert('Có lỗi xảy ra khi gửi comment');
        },
    });

    function updateCommentSection(newComment) {
        var commentSection = document.getElementById('commentSection');
        var commentElement = document.createElement('ul');
        commentElement.className = 'comment-list';
        commentElement.innerHTML = `
        <li class="comment" >
           <div class="vcard bio">
              <img src="/images/person_1.jpg" alt="Image placeholder">
           </div>
           <div class="comment-body">
              <h3>${newComment.name}</h3>
              <div class="meta mb-2">${newComment.date.toLocaleDateString() + ' ' + newComment.date.toLocaleTimeString() }</div>
              <p>${newComment.message}</p>
           </div></li>
        `;
        commentSection.prepend(commentElement);
    }

    document.getElementById('name').value = '';
    document.getElementById('email').value = '';
    document.getElementById('message').value = '';
}
);