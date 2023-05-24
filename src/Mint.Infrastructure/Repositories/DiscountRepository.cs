using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mint.Infrastructure.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly ApplicationDbContext _context;

    public DiscountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DiscountViewModel>> GetDiscountsAsync()
    {
        try
        {
            var discounts = await _context.Discounts
                .AsNoTracking()
                .ToListAsync();
            return new DiscountManager().FomingMultiViewModels(discounts);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<DiscountViewModel> GetDiscountByIdAsync(Guid id)
    {
        try
        {
            var discount = await _context.Discounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Акция не найдена.");

            return new DiscountManager().FomingSingleViewModel(discount);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<DiscountViewModel> AddDiscountAsync(DiscountBindingModel model)
    {
        try
        {
            var discount = new DiscountManager().FormingSingleBindingModel(model);

            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();

            return new DiscountManager().FomingSingleViewModel(discount);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateDiscountAsync(DiscountBindingModel model)
    {
        try
        {
            var discount = await _context.Discounts
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new Exception("Акция не найдена.");

            discount.Name = model.Name!;
            discount.ActiveDateUntil = model.UntilDate == discount.ActiveDateUntil ? discount.ActiveDateUntil : model.UntilDate;
            discount.Percent = model.Percent == discount.Percent ? discount.Percent : model.Percent;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteDiscountAsync(Guid id)
    {
        try
        {
            var discount = await _context.Discounts
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Акция не найдена.");

            _context.Remove(discount);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
