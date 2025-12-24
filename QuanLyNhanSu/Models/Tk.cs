using System;
using System.Collections.Generic;

namespace QuanLyNhanSu.Models;

public partial class TK
{
    public string TenTk { get; set; } = null!;

    public int IdNv { get; set; }

    public string MKhauTk { get; set; } = null!;

    public string? VaiTro { get; set; }
    public virtual Nv IdNvNavigation { get; set; } = null!;
}