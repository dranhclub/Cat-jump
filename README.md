# Cat-jump
A simple game made with Unity

## Mô tả: 
Trò chơi điều khiển nhân vật là mèo Yummi, nhảy nhót trên các khối vuông lơ lửng trên bầu trời, vượt qua các chướng ngại vật và đến đích.

## Điều khiển nhân vật:
- Yummi có thể di chuyển tiến (W), lùi (S) và xoay (A, D)
- Yummi có thể nhảy bằng cách giữ phím Space. Thời gian giữ càng lâu, nhảy càng xa.
- Có giới hạn lực nhảy tối thiểu và tối đa.
- Chỉ nhảy được khi đang chạm vào mặt đất.

## Các đối tượng: Mặt đất, bẫy, nước, ngôi sao, nút bấm, cổng dịch chuyển, checkpoint.
- Mặt đất: Yummi có thể đứng và di chuyển bình thường.
- Bẫy: Giẫm vào sẽ chết.
- Nước: Giẫm vào sẽ tụt xuống và cũng chết.
- Nút bấm: Giẫm vào sẽ mở cầu
- Cầu: Di chuyển như trên mặt đất
- Cổng dịch chuyển: Đích đến
- Ngôi sao: Ăn để tăng mạng
- Checkpoint: Nơi Yummi hồi sinh.

## Lối chơi:
- Yummi vượt qua bẫy, khoảng trống, nước để tới đích. 
- Nếu giẫm phải bẫy hoặc rơi xuống, Yummi sẽ chết.
- Nếu chết, Yummi sẽ hồi sinh ở checkpoint và trừ một mạng.
- Nếu hết mạng, trò chơi kết thúc. 
- Ăn ngôi sao để tăng mạng. 
- Yummi cần đi tới các nút bấm để có thể mở cầu, để đi đến những nơi xa hơn trong bản đồ.
