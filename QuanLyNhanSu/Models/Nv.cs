using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanSu.Models;

public partial class Nv
{
    public Nv()
    {
        ChamCongs = new HashSet<ChamCong>();
        DonNghiPheps = new HashSet<DonNghiPhep>();
        Luongs = new HashSet<Luong>();
        Tks = new HashSet<TK>();
    }

    public int IdNv { get; set; }

    public string NvTen { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? Chucvu { get; set; }

    public string? DiaChi { get; set; }

    public string? SDt { get; set; }

    public string? Email { get; set; }

    public string? PhongBan { get; set; }

    public decimal? LuongCoBan { get; set; }

    public virtual ICollection<ChamCong> ChamCongs { get; set; }
    public virtual ICollection<DonNghiPhep> DonNghiPheps { get; set; }
    public virtual ICollection<Luong> Luongs { get; set; }
    public virtual ICollection<TK> Tks { get; set; }
}