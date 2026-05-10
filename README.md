# 🎮 dv02_LoLSurvival (Refactored)

Một dự án game survival lấy cảm hứng từ League of Legends (LoL), được xây dựng và tối ưu hóa trên nền tảng Unity. Dự án tập trung vào việc áp dụng **Clean Architecture**, tính modular cao và khả năng mở rộng thông qua hệ thống dữ liệu tập trung.

## 📺 Video Demo (Gameplay)

[![LoL Survival Gameplay](https://img.youtube.com/vi/vrNMCY5JNYw/maxresdefault.jpg)](https://youtu.be/vrNMCY5JNYw)

*Click vào hình trên để xem video demo gameplay trên YouTube.*

---

## 🌟 Các Tính Năng Nổi Bật (Key Features)

### ⚔️ Hệ Thống Chiến Đấu (Combat System)
*   **Chỉ số sâu (Deep Stats):** Quản lý qua `CombatService`, hỗ trợ các thuộc tính phức tạp như: *Armor Penetration, Life Steal, Omnivamp, Crit Damage, Cooldown Reduction...*
*   **Modifier System:** Hỗ trợ tính toán đa lớp (Flat, PercentAdd, PercentMult) giúp dễ dàng cân bằng game.
*   **Feedback trực quan:** Hiệu ứng âm thanh và hình ảnh đồng bộ với logic chiến đấu.

### 🧬 Hệ Thống Thăng Cấp & Talent
*   **Deep Copy Rarity:** Sử dụng cơ chế sao chép sâu để quản lý tỷ lệ xuất hiện vật phẩm (`RarityData`) mà không làm ảnh hưởng đến dữ liệu gốc trong ScriptableObject.
*   **Permanent Upgrades:** Hệ thống **Talent** cho phép người chơi nâng cấp vĩnh viễn các chỉ số cơ bản, được lưu trữ an toàn qua JSON.
*   **Hệ thống Skill:** Nâng cấp kỹ năng và chỉ số động trong trận đấu thông qua `UpgradeSo`.

### 💾 Hệ Thống Lưu Trữ (Persistence)
*   **Encrypted JSON:** Dữ liệu người chơi (Tiền tệ, Talent, Tiến trình) được mã hóa và lưu dưới dạng JSON.
*   **Auto-Save:** Tự động đồng bộ hóa tiến trình sau mỗi trận đấu.

### 🤖 Trí Tuệ Nhân Tạo (AI & State Machine)
*   **Robust State Machine:** Tất cả thực thể (Player, Enemy, Boss) được vận hành bởi State Machine mạnh mẽ, tách biệt hoàn toàn logic di chuyển, tấn công và trạng thái (Idle, Move, Attack, Die).

---

## 🏗 Kiến Trúc Dự Án (Architecture)

Dự án được xây dựng trên nền tảng framework **VyesBase**, áp dụng mô hình **Controller - View - Model**:

*   **Logic Tách Biệt:** Controller xử lý logic nghiệp vụ, View xử lý hiển thị/hiệu ứng, và Model quản lý dữ liệu.
*   **Service-Oriented:** Các module lớn (Save, Talent, Stat, Combat) được đóng gói trong các Service độc lập.
*   **Object Pooling:** Tối ưu hiệu năng bằng cách tái sử dụng quái vật, đạn và hiệu ứng hình ảnh.

### 📂 Cấu trúc thư mục chính
```text
Assets/
├── _Data/
│   ├── Refactor/          # Toàn bộ mã nguồn đã Refactor
│   │   ├── Controllers/   # Logic điều khiển thực thể (Player, Enemy, Spawner)
│   │   ├── Models/        # Dữ liệu Runtime và ScriptableObject (SOs)
│   │   ├── Services/      # Các dịch vụ xử lý logic lõi
│   │   ├── States/        # Các trạng thái của thực thể (State Machine)
│   │   └── Views/         # Giao diện UI và hiển thị trực quan
│   ├── Scenes/            # Các màn chơi (Init -> MainMenu -> GamePlay)
│   └── Prefabs/           # Tài nguyên 3D (.glb) và Prefab chuẩn hóa
└── VyesBase/              # Framework kiến trúc nền tảng
```

---

## 🚀 Hướng Dẫn Bắt Đầu (Getting Started)

1.  **Khởi tạo:** Luôn bắt đầu từ Scene `Assets/_Data/Scenes/Init.unity` để hệ thống Singleton và Service được khởi tạo đúng cách.
2.  **Điều khiển:** 
    *   Sử dụng phím **WASD** hoặc **Mũi tên** để di chuyển.
    *   Nhân vật sẽ tự động nhắm mục tiêu vào kẻ địch gần nhất.
3.  **Mục tiêu:** Tiêu diệt quái vật để thu thập EXP, thăng cấp và chọn các kỹ năng nâng cấp để tồn tại lâu nhất có thể.

---

## 🛠 Công Nghệ Sử Dụng (Tech Stack)

*   **Engine:** Unity 6 (Version mới nhất).
*   **Ngôn ngữ:** C# .NET.
*   **Thư viện:**
    *   **DOTween:** Xử lý các hiệu ứng chuyển động và UI mượt mà.
    *   **JSON.NET:** Xử lý lưu trữ và cấu trúc dữ liệu.
    *   **VyesBase:** Framework nền tảng tự phát triển.

---
*Dự án đã được dọn dẹp sạch sẽ (Loại bỏ Legacy Code) và sẵn sàng cho việc mở rộng thêm các tướng và kỹ năng mới từ vũ trụ LoL.*
