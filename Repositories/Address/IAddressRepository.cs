using TEST_CRUD.DTO.AddressDTO;

namespace TEST_CRUD.Repositories
{
    public interface IAddressRepository
    {
        public Task<IEnumerable<Address>> GetList();
        public Task<Address?> GetById(int id);
        public Task<Address?> Add(Address address);
        public Task<Address?> Update(AddAddressDto address, int id);
        public Task<Address?> Delete(int id);
    }
}
