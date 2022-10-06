-- 2. Menambahkan data Jabatan
INSERT INTO Jabatan (Nama, GajiPokok, Tunjangan)
VALUES ('Direktur', '25000000', '5000000'),
('Manajer', '15000000', '3000000'),
('Karyawan_T1', '7500000', '1500000'),
('Karyawan_T2', '5000000', '1500000');

SELECT * FROM Jabatan

-- 2. Menambahkan data Karyawan
INSERT INTO Karyawan (NamaLengkap, NomerTelepon, NomerRekening, Email,JabatanID)
VALUES ('Agus Kuncoro', '081234567891', '897654321','agus@email.com', '1'),
('Siti Kusmini', '081234567899', '897654123','siti@email.com', '2'),
('Asa Kabaret', '081234567898', '897654124','asa@email.com', '3'),
('Muhammad Abidin', '081234567897', '897654125','abidin@email.com', '3'),
('Gita Devi', '081234567896', '897654126','gita@email.com', '4'),
('Marie Safitri', '081234567895', '897654127','marie@email.com', '4');

SELECT * FROM Karyawan -- check isi tabel Karyawan

-- 3. Menambahkan data Bonus
INSERT INTO Bonus (KaryawanID, Tanggal, Jumlah, Keterangan)
VALUES ('3', '2022-09-12', 200000, 'Performa Baik'),
('4', '2022-09-12', 200000, 'Performa Baik'),
('5', '2022-09-12', 2000000, 'Bonus Karyawan Teladan'),
('2', '2022-10-12', 300000, 'Profit Meningkat'),
('2', '2022-10-12', 300000, 'Profit Meningkat'),
('5', '2022-10-12', 3000000, 'Bonus Karyawan Teladan');

SELECT * FROM Bonus -- check isi tabel Bonus

-- 4. Menambahkan data Lembur
INSERT INTO Lembur (KaryawanID, Tanggal, JumlahJam, Keterangan)
VALUES ('3', '2022-09-10', 2, 'Bertemu Client'),
('4', '2022-09-10', 3, 'Sorting Dokumen'),
('4', '2022-09-12', 1, 'Bertemu Client'),
('5', '2022-10-10', 2,'Input Data');

SELECT * FROM Lembur -- check isi tabel Lembur

-- 5. Menambahkan data Potongan
INSERT INTO Potongan (KaryawanID, Tanggal, Jumlah, Keterangan)
VALUES ('2', '2022-09-11', 500000, 'Merusak Barang Kantor'),
('3', '2022-09-11', 50000, 'Terlambat Masuk'),
('6', '2022-09-12', 30000, 'Terlambat Masuk'),
('5', '2022-10-11', 50000, 'Terlambat Masuk');

SELECT * FROM Potongan

-- 6. Menambahkan Data Cuti
INSERT INTO Cuti (KaryawanID, Tanggal, JumlahHari, Keterangan)
VALUES ('2', '2022-09-11', 2, 'Saudara Menikah'),
('3', '2022-09-11', 1, 'Liburan'),
('6', '2022-09-12', 3, 'Acara Keluarga'),
('5', '2022-10-11', 2, 'Acara Keluarga'),
('4', '2022-10-11', 2, 'Orangtua Sakit'),
('4', '2022-10-20', 3, 'Acara Keluarga');

SELECT * FROM Cuti