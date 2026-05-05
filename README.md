# dv02_LoLSurvival (Refactored)

Một dự án game survival lấy cảm hứng từ League of Legends, được xây dựng và tối ưu hóa trên nền tảng Unity. Dự án đã qua quá trình Refactor toàn diện để đạt được kiến trúc sạch (Clean Architecture) và hiệu suất cao.

## 🏗 Kiến trúc dự án (Architecture)

Dự án sử dụng framework **VyesBase**, tập trung vào tính modular, dễ mở rộng và quản lý dữ liệu tập trung:

- **Namespace Core**: `_Data.Refactor` (Mã nguồn chính) và `VyesBase` (Hệ thống nền tảng).
- **State Machine**: Tất cả thực thể (Player, Enemy, Boss) được quản lý bằng State Machine mạnh mẽ, giúp tách biệt logic di chuyển, tấn công và trạng thái.
- **Service-Oriented**: Các logic tính toán (Combat, Leveling, Save/Load) được đóng gói trong các Service riêng biệt.
- **Data-Driven**: Sử dụng `ScriptableObject` (SO) để quản lý toàn bộ chỉ số, kỹ năng và vật phẩm.

## 📂 Cấu trúc thư mục chính

```
Assets/
├── _Data/
│   ├── Refactor/          # Toàn bộ mã nguồn mới
│   │   ├── Controllers/   # Điều khiển thực thể (Player, Enemy, Spawner)
│   │   ├── Models/        # Dữ liệu Runtime và ScriptableObject
│   │   ├── Services/      # Các dịch vụ xử lý logic (Save, Talent, Stat)
│   │   ├── States/        # Các trạng thái của thực thể (Idle, Move, Attack, Die)
│   │   └── Views/         # Giao diện UI (Panels, UIs)
│   ├── Scenes/            # Các màn chơi (Init, MainMenu, GamePlay...)
│   └── Prefabs/           # Các mô hình 3D (.glb) và Prefab
└── VyesBase/              # Framework kiến trúc nền tảng
```

## 🚀 Các hệ thống lõi (Core Systems)

### 1. Hệ thống Chiến đấu (Combat System)
- Quản lý sát thương qua `CombatService`.
- Hỗ trợ các chỉ số phức tạp: Armor Pen, Life Steal, Omnivamp, Crit Damage...

### 2. Hệ thống Thăng cấp & Rarity
- `RarityRuntime` sử dụng cơ chế **Deep Copy** để đảm bảo việc thay đổi tỷ lệ khi chơi không làm ảnh hưởng đến dữ liệu gốc trong ScriptableObject.
- Nâng cấp kỹ năng và chỉ số động thông qua `UpgradeSo`.

### 3. Hệ thống Âm thanh (Sound Manager)
- Quản lý tập trung qua `SoundManager` với `CustomDictionary`.
- Hỗ trợ phân loại âm lượng Music và SFX riêng biệt.

### 4. Hệ thống Lưu trữ (Persistence)
- Tự động lưu trữ điểm CS và tiến trình Talent qua `SaveService`.
- Dữ liệu được mã hóa và lưu dưới dạng JSON.

## 🎮 Hướng dẫn bắt đầu

1. Mở Scene: `Assets/_Data/Scenes/Init.unity`.
2. Nhấn **Play** để khởi tạo các Singleton và chuyển sang `MainMenu`.
3. Trong `GamePlay`, sử dụng các phím điều hướng để di chuyển và hạ gục kẻ địch.

---
*Dự án đã được dọn dẹp sạch sẽ (Loại bỏ hoàn toàn Legacy Code) và sẵn sàng cho việc phát triển thêm các tính năng mới.*
