# Manajemen Data Karyawan

## Deskripsi
Proyek ini adalah aplikasi Windows Forms berbasis C# yang digunakan untuk mengelola data karyawan. Aplikasi ini memungkinkan pengguna untuk menambahkan, mengedit, menghapus, dan menampilkan data karyawan menggunakan database SQLite.

## Fitur
- **Tambah Karyawan**: Menambahkan data karyawan baru ke dalam database.
- **Edit Karyawan**: Mengedit informasi karyawan yang sudah ada.
- **Hapus Karyawan**: Menghapus data karyawan dari database.
- **Tampilkan Data**: Menampilkan seluruh data karyawan dalam tabel.
- **Pembersihan Formulir**: Membersihkan semua inputan pada formulir untuk entri baru.
- **Klik Tabel untuk Edit**: Memilih data dari tabel untuk diedit dengan mengklik baris yang diinginkan.

## Teknologi yang Digunakan
- **C# .NET (Windows Forms)**: Framework utama untuk membangun aplikasi desktop.
- **SQLite**: Database yang digunakan untuk menyimpan data karyawan.

## Struktur Database
Nama tabel: `Karyawan`

| Kolom           | Tipe Data   | Deskripsi                      |
|----------------|------------|--------------------------------|
| ID            | INTEGER (PK, AUTOINCREMENT) | ID unik karyawan |
| Nama          | TEXT        | Nama lengkap karyawan         |
| Jabatan       | TEXT        | Jabatan karyawan              |
| Gaji          | REAL        | Gaji karyawan                 |
| TanggalBergabung | TEXT    | Tanggal mulai bekerja         |
| Status        | TEXT        | Status karyawan (aktif/nonaktif) |
| Telepon       | TEXT        | Nomor telepon karyawan        |
| Alamat        | TEXT        | Alamat tempat tinggal         |
| Email         | TEXT        | Email karyawan                |

## Cara Menjalankan Aplikasi
1. **Clone atau Download** repository proyek ini.
2. **Buka proyek** menggunakan Visual Studio.
3. **Pastikan SQLite Database sudah terpasang**.
4. **Jalankan aplikasi** dengan menekan tombol `Start` di Visual Studio.

## Penggunaan
- Masukkan data karyawan pada formulir yang tersedia.
- Klik **Simpan** untuk menyimpan data baru.
- Pilih baris pada tabel dan klik **Edit** untuk memperbarui informasi.
- Pilih baris pada tabel dan klik **Hapus** untuk menghapus data.
- Klik **Bersih** untuk mengosongkan formulir input.

## Kontributor
Proyek ini dikembangkan oleh [Nama Anda]. Jika ada pertanyaan atau saran, silakan hubungi melalui email atau platform lainnya.

---
Terima kasih telah menggunakan aplikasi ini! 🚀

