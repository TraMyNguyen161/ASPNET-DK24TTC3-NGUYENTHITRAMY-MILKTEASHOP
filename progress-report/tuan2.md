# <!DOCTYPE html>

# <html>

# <head>

# &nbsp;   <meta name="viewport" content="width=device-width" />

# &nbsp;   <title>TIỆM TRÀ SỮA MILK TEA</title>

# &nbsp;   <style>

# &nbsp;       body {

# &nbsp;           font-family: Arial, sans-serif;

# &nbsp;           margin: 0;

# &nbsp;           background-image: url('https://i.imgur.com/WbQb8BA.jpeg');

# &nbsp;           background-size: contain;

# &nbsp;       }

# 

# &nbsp;       header {

# &nbsp;           position: relative;

# &nbsp;           height: 600px;

# &nbsp;           text-align: center;

# &nbsp;           padding: 20px 0;

# &nbsp;           background-image: url('https://i.imgur.com/elwUW1J.jpeg');

# &nbsp;           background-size: cover;

# &nbsp;           background-position: center;

# &nbsp;       }

# &nbsp;       /\* Nút giỏ hàng \*/

# &nbsp;       .cart-btn {

# &nbsp;           float: right;

# &nbsp;           font-size: 18px;

# &nbsp;           text-decoration: none;

# &nbsp;           text-align: center;

# &nbsp;           background: #ff9800;

# &nbsp;           border-radius: 5px;

# &nbsp;           color: white;

# &nbsp;       }

# &nbsp;           nav {

# &nbsp;           background-color:;

# &nbsp;           display: flex;

# &nbsp;           justify-content: center;

# &nbsp;           }

# 

# &nbsp;           nav {

# &nbsp;           display: flex;

# &nbsp;           gap: 25px; /\* giãn đều giữa các nút \*/

# &nbsp;            }

# &nbsp;           /\* Khi nút được chọn (active) \*/

# &nbsp;           nav a {

# &nbsp;               color: #b84e6a;

# &nbsp;               text-decoration: none;

# &nbsp;               font-weight: 600;

# &nbsp;               padding: 10px 22px;

# &nbsp;               border-radius: 25px;

# &nbsp;               padding: 20px 40px;

# &nbsp;               border: 2px solid rgba(255, 182, 193, 0.5); /\* 🌸 viền hồng mờ 50% \*/

# &nbsp;               transition: all 0.3s ease;

# &nbsp;           }

# 

# &nbsp;           nav a.active {

# &nbsp;                   background-color: #ff7b9c;

# &nbsp;                   color: white;

# &nbsp;                   border-color: #ff7b9c;

# &nbsp;               }

# &nbsp;           nav a:hover {

# &nbsp;                   background-color: #ff9bb3;

# &nbsp;                   color: white;

# &nbsp;                   transform: translateY(-2px);

# &nbsp;                   box-shadow: 0 3px 10px rgba(255, 182, 193, 0.6);

# &nbsp;               }

# &nbsp;                         

# &nbsp;           nav a:hover {

# &nbsp;                   background-color: #99CCCC;

# &nbsp;               }

# 

# &nbsp;       .container {

# &nbsp;           display: flex;

# &nbsp;           flex-wrap: wrap;

# &nbsp;           justify-content: center;

# &nbsp;           margin: 30px auto;

# &nbsp;           max-width: 1000px;

# &nbsp;       }

# 

# &nbsp;       .product {

# &nbsp;           background-color: white;

# &nbsp;           border-radius: 10px;

# &nbsp;           box-shadow: 0 2px 8px rgba(0,0,0,0.1);

# &nbsp;           margin: 15px;

# &nbsp;           padding: 15px;

# &nbsp;           width: 250px;

# &nbsp;           text-align: center;

# &nbsp;           transition: transform 0.3s;

# &nbsp;       }

# 

# &nbsp;           .product:hover {

# &nbsp;               transform: scale(1.05);

# &nbsp;           }

# 

# &nbsp;           header img {

# &nbsp;           padding: 60px 60px 60px 60px;

# &nbsp;           width: 250px; /\* Kích thước logo \*/

# &nbsp;           height: 250px;

# &nbsp;           border-radius: 50%; /\* Bo tròn logo nếu muốn \*/

# &nbsp;       }

# 

# &nbsp;           .product img {

# &nbsp;               width: 100%;

# &nbsp;               border-radius: 10px;

# &nbsp;           }

# 

# &nbsp;           .product h3 {

# &nbsp;               margin: 10px 0 5px;

# &nbsp;           }

# 

# &nbsp;           .product p {

# &nbsp;               color: #555;

# &nbsp;           }

# 

# &nbsp;       .price {

# &nbsp;           color: #e74c3c;

# &nbsp;           font-weight: bold;

# &nbsp;           margin-bottom: 10px;

# &nbsp;       }

# 

# &nbsp;       .btn {

# &nbsp;           background-color: #ff6b6b;

# &nbsp;           color: white;

# &nbsp;           padding: 10px 20px;

# &nbsp;           border: none;

# &nbsp;           border-radius: 20px;

# &nbsp;           cursor: pointer;

# &nbsp;       }

# 

# &nbsp;           .btn:hover {

# &nbsp;               background-color: #ff3b3b;

# &nbsp;           }

# 

# &nbsp;           footer {

# &nbsp;           background-color: #333;

# &nbsp;           color: white;

# &nbsp;           text-align: left;

# &nbsp;           height: 200px;

# &nbsp;       }

# &nbsp;   </style>

# &nbsp;   </head>

# <body>

# &nbsp;   <header>

# &nbsp;       <img src="https://i.imgur.com/R57ULYt.jpeg" alt="Logo Cửa Hàng">

# &nbsp;       <div>

# &nbsp;           

# &nbsp;       </div>

# &nbsp;   </header>

# 

# &nbsp;   <nav>

# &nbsp;       

# &nbsp;       <a href="#" class="active">Trang chủ</a>

# &nbsp;       <a href="#" class="active">Sản phẩm</a>

# &nbsp;       <a href="#" class="active">Giới thiệu</a>

# &nbsp;       <a href="#" class="active">Liên hệ</a>

# &nbsp;       <!-- Nút giỏ hàng -->

# &nbsp;       <a href="cart.cshtml" class="cart-btn">🛒 Giỏ hàng (0)</a>

# &nbsp;   </nav>

# 

# &nbsp;   <div class="container">

# &nbsp;       <div class="product">

# &nbsp;           <img src="https://i.imgur.com/aViAKbH.jpeg" alt="">

# &nbsp;           <h3>Trà Sữa Truyền Thống</h3>

# &nbsp;           <p>Chân châu đường đen, chocolate, mattcha,...</p>

# &nbsp;           <div class="price">32.000đ</div>

# &nbsp;           <button class="btn">Đặt ngay</button>

# &nbsp;       </div>

# 

# &nbsp;       <div class="product">

# &nbsp;           <img src="https://i.imgur.com/A9veVoT.jpeg" alt="">

# &nbsp;           <h3>Trà Trái Cây</h3>

# &nbsp;           <p>Trà trái cây nhiệt đới, trà dưa lưới, hồng trà,...</p>

# &nbsp;           <div class="price">35.000đ</div>

# &nbsp;           <button class="btn">Đặt ngay</button>

# &nbsp;       </div>

# 

# &nbsp;       <div class="product">

# &nbsp;           <img src="https://i.imgur.com/Fw6JQ5I.jpeg" alt="">

# &nbsp;           <h3>Sinh Tố</h3>

# &nbsp;           <p>Mãng cầu, dâu, xoài, bơ, sầu riêng,....</p>

# &nbsp;           <div class="price">40.000đ </div>

# &nbsp;           <button class="btn">Đặt ngay</button>

# &nbsp;       </div>

# &nbsp;       <div class="product">

# &nbsp;           <img src="https://i.imgur.com/M3YHdou.jpeg" />

# &nbsp;           <h3>Soda</h3>

# &nbsp;           <p>Soda dâu, dưa lưới, đào, việt quất</p>

# &nbsp;           <div class="price">42.000đ</div>

# &nbsp;           <buttton class="btn">Đặt ngay</buttton>

# &nbsp;       </div>

# &nbsp;   </div>

# 

# &nbsp;   <footer class="bg-dark text-white py-4 mt-5">

# &nbsp;       <div class="container text-center">

# &nbsp;           <p class="mb-2">Theo dõi chúng tôi:</p>

# &nbsp;           <div class="d-flex justify-content-center gap-3 mb-3">

# &nbsp;               <a href="https://Zalo.me/0389104781" class="text-white"><i class="bi bi-facebook fs-4"></i></a>

# &nbsp;               <a href="#" class="text-white"><i class="bi bi-twitter fs-4"></i></a>

# &nbsp;               <a href="#" class="text-white"><i class="bi bi-instagram fs-4"></i></a>

# &nbsp;           </div>

# &nbsp;       </div>

# &nbsp;   </footer>

# &nbsp;   

# &nbsp;   <div>

# &nbsp;       @RenderBody()

# &nbsp;   </div>

# </body>

# </html>

