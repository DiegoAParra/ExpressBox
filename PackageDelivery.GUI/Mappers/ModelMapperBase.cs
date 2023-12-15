using System.Collections.Generic;

namespace PackageDelivery.GUI.Implementation.Mappers
{
    public abstract class ModelMapperBase<ModelType, DTOType>
    {
        public abstract ModelType DTOToModelMapper(DTOType input);
        public abstract DTOType ModelToDTOMapper(ModelType input);
        public abstract IEnumerable<ModelType> DTOToModelMapper(IEnumerable<DTOType> input);
        public abstract IEnumerable<DTOType> ModelToDTOMapper(IEnumerable<ModelType> input);
        
    }
}
